cd build 
cmake -S ../ -B . -G "MinGW Makefiles" -DCMAKE_BUILD_TYPE=Debug
make
cd ..
cp ./build/libSqlFuncs.a ../libs
cp ./src/sqlsys.h ../

if ($args[0] -eq "exe") {
	if(Test-Path "./test/SqlFuncs.exe") {
		rm ./test/SqlFuncs.exe
	}

	mv ./build/SqlFuncs.exe ./test/	
}
