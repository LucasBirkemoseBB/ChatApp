# Recursively find all files with extensions '.c' or '.h' and format them with clang-format
Get-ChildItem -Recurse -Include *.c,*.h |
ForEach-Object {
    clang-format -i -style=file $_.FullName
}

