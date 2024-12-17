package main

/*
#cgo LDFLAGS: -Llibs -lSqlFuncs -lsqlite3
#cgo CFLAGS: -Iincludes
#include "sqlsys.h"

*/
import "C"
import (
	"fmt"
)

func main() {
	fmt.Println("Bruh...")

	var connection C.struct_database_connection
	C.connect_database(&connection, C.CString("databse.db"))

	var args **C.char

	C.execute_sql_file(&connection, C.CString("base.sql"), args, 0)

	C.close_database(&connection)
}
