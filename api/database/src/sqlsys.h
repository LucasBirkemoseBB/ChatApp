#ifndef SQLSYS_H
#define SQLSYS_H

#include <stdio.h>
#include <stdlib.h>

#include <string.h>

#include <sqlite3.h>

union column_value {
        int ival;
        char* sval;
};

struct column {
        char* name;

        union column_value value;

        struct column* next;
        struct column* prev;
};

struct row {
        int columns;
        struct column* root; // Usually used to store ID

        struct row* next;
        struct row* prev;
};

struct table {
        char* name;
        struct row* root;
};

struct database_connection {
        sqlite3* database;
        int database_handle;

        struct table tables[64];
};

union format_arguments {
        char* string;
        double decimal;
        int integer;
};

void connect_database(struct database_connection* connection,
                      const char* database_name);
void close_database(struct database_connection* connection);

void execute_sql_string(struct database_connection* connection,
                        const char* string);

void execute_sql_file(struct database_connection* connection,
                      const char* filename, char** args, size_t arg_count);

//==========================================================================================================================================================

#endif
