Как настроить для решения мердж конфликтов Visual Studio
Должен быть путь:
"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer"

Mergetool command:

"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer/vsdiffmerge.exe" /m /t "$LOCAL" "$REMOTE" "$BASE" "$MERGED"

Difftool command:

"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer/vsdiffmerge.exe" /t "$LOCAL" "$REMOTE"
