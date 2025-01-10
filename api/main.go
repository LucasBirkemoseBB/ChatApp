package main

/*
#cgo LDFLAGS: -Llibs -lSqlFuncs -lsqlite3
#cgo CFLAGS: -Iincludes
#include "sqlsys.h"

*/
import "C"

type callval struct {
	names  **C.char
	values **C.char
	count  C.int
}

func main() {
	var connection C.struct_database_connection
	C.connect_database(&connection, C.CString("databse.db"))

	var args **C.char

	C.execute_sql_file(&connection, C.CString("base.sql"), args, 0)
	C.execute_sql_file(&connection, C.CString("getfrom.sql"), args, 0)

	C.close_database(&connection)
}
