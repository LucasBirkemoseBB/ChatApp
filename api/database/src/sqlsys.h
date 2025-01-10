#ifndef SQLSYS_H
#define SQLSYS_H

#include <sqlite3.h>

struct callbackvalues {
	char** names;
	char** values;
	int count;
};

struct database_connection {
        sqlite3* database;
        int database_handle;

};

union format_arguments {
        char* string;
        double decimal;
        int integer;
};

void connect_database(struct database_connection* connection,
                      const char* database_name);
void close_database(struct database_connection* connection);

struct callbackvalues execute_sql_string(struct database_connection* connection,
                        const char* string);

struct callbackvalues execute_sql_file(struct database_connection* connection,
                      const char* filename, char** args, size_t arg_count);

//==========================================================================================================================================================

#endif
