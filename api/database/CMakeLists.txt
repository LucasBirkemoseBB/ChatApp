cmake_minimum_required(VERSION 3.11.0)
set(NAME SqlFuncs)
project(${NAME} VERSION 0.0.1)

# Paths to necessary tools and libraries
set(MINGW_PATH C:/msys64/ucrt64)
set(SQLITE_PATH C:/sqlite)

message(STATUS "Using ${CMAKE_GENERATOR}")

if (CMAKE_GENERATOR STREQUAL "MinGW Makefiles")
    set(USE_MINGW "True")
    set(CMAKE_C_COMPILER ${MINGW_PATH}/bin/gcc.exe)
    set(CMAKE_CXX_COMPILER  ${MINGW_PATH}/bin/g++.exe)
endif()

# Find all source files
file(GLOB_RECURSE SOURCES
    src/*.h
    src/*.c
)

# Define the shared library
add_library(${NAME} ${SOURCES})
# add_executable(${NAME} ${SOURCES})

target_link_libraries(${NAME} PRIVATE ${SQLITE_PATH}/libs/sqlite3.dll)
target_include_directories(${NAME} PRIVATE ${SQLITE_PATH}/include)
