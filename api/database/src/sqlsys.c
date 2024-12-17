#include <stdio.h>
#include <stdlib.h>

#include <string.h>

#include "sqlsys.h"

void format_string(const char* filename, char** dst, char** args,
                   size_t arg_count);
char* replace_segment(char* string, char* replace, int l, int r, int stringlen,
                      int replacelen);

void read_file(const char* filename, char** dst);

/*
 *	void *data: 			A pointer to any user-defined data that
 *you may want to pass to the callback function. This allows you to use the
 *callback function for a variety of purposes, such as accumulating results or
 *passing context.
 *
 *  int count: 				The number of columns in the result set
 *(i.e., the number of fields in each row).
 *
 *  char **values: 		An array of strings representing the values of
 *the columns for the current row. Each element of argv is a string that
 *represents the value of a column.
 *
 *  char **columns: 	An array of strings representing the column names.
 *azColName[i] corresponds to the column name for argv[i].
 */

static int _callback(void* data, int count, char** values, char** columns) {
        struct database_connection* connection =
            (struct database_connection*)(data);

        printf("Count: %d\n", count);

        for (int i = 0; i < count; ++i) {
                printf("Name: %s, value: %s\n", columns[i], values[i]);
        }
        return 0;
}

void connect_database(struct database_connection* connection,
                      const char* database_name) {
        connection->database_handle =
            sqlite3_open(database_name, &connection->database);

        if (connection->database_handle != SQLITE_OK) {
                fprintf(stderr,
                        "Failed to connect to the database: %s with error "
                        "code: %s\n",
                        database_name, sqlite3_errmsg(connection->database));
                sqlite3_close(connection->database);
                return;
        }
}

void close_database(struct database_connection* connection) {
        sqlite3_close(connection->database);
}

void execute_sql_string(struct database_connection* connection,
                        const char* string) {
        char* errmsg;
        connection->database_handle = sqlite3_exec(
            connection->database, string, _callback, connection, &errmsg);

        if (connection->database_handle != SQLITE_OK) {
                fprintf(stderr, "Failed to execute sql string. %s!\n",
                        sqlite3_errmsg(connection->database));

                sqlite3_free(errmsg);
                sqlite3_close(connection->database);
                return;
        }
}

void execute_sql_file(struct database_connection* connection,
                      const char* filename, char** args, size_t arg_count) {
        char* buffer;
        va_list ap;

        read_file(filename,
                  &buffer); // Assume `read_file` dynamically allocates `*dst`
        format_string(filename, &buffer, args, arg_count);

        execute_sql_string(connection, buffer);
        free(buffer);
}

//==========================================================================================================================================================
void format_string(const char* filename, char** dst, char** args,
                   size_t arg_count) {
        char* str = *dst;

        char p;
        int argn = 0;

        union format_arguments format;
        for (int i = 0; i < strlen(str); ++i) {
                p = str[i];
                if (p != '$' || argn >= arg_count) {
                        continue;
                }

                format.string = args[argn];
                str = replace_segment(str, format.string, i, i, strlen(str),
                                      strlen(format.string));
                argn++;
        }

        *dst = str;
}

char* replace_segment(char* string, char* replace, int l, int r, int stringlen,
                      int replacelen) {
        int segment_len = (r - l) + 1;
        int rest = stringlen - segment_len - l;

        size_t size = stringlen - segment_len + replacelen;

        char* buffer;
        buffer = malloc((size + 1) * sizeof(char));

        memcpy(buffer, string, l * sizeof(char));
        memcpy(&buffer[l], replace, replacelen * sizeof(char));
        memcpy(&buffer[l + replacelen], &string[r + 1], rest * sizeof(char));

        return buffer;
}

void read_file(const char* filename, char** dst) {
        FILE* fptr;
        fopen_s(&fptr, filename, "rb");

        if (fptr == NULL) {
                printf("Failed to open file: %s\n", filename);
                return;
        }

        size_t file_size;
        fseek(fptr, 0L, SEEK_END);
        file_size = ftell(fptr);
        rewind(fptr);

        *dst = malloc((file_size + 1) * sizeof(char));
        fread(*dst, 1, file_size, fptr);
        (*dst)[file_size] = '\0';
        fclose(fptr);
}

int main(void) {
        struct database_connection connection;
        connect_database(&connection, "databse.db");

        // execute_sql_file(&connection, "base.sql", NULL, 0);

        execute_sql_file(&connection, "insert.sql",
                         (char*[]){"Users", "UserName, DOC, PFP",
                                   "'James', '29/10/2024', 'somepng.png'"},
                         3);

        execute_sql_file(&connection, "table.sql", (char*[]){"Users"}, 1);

        close_database(&connection);
}
