Как настроить для решения мердж конфликтов Visual Studio
Должен быть путь:
"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer"

Mergetool command:

"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer/vsdiffmerge.exe" /m /t "$LOCAL" "$REMOTE" "$BASE" "$MERGED"

Difftool command:

"C:/Program Files (x86)/Microsoft Visual Studio/2017/Community/Common7/IDE/CommonExtensions/Microsoft/TeamFoundation/Team Explorer/vsdiffmerge.exe" /t "$LOCAL" "$REMOTE"


![git merge util example](https://github.com/milovidov983/Cribs-and-tips/blob/master/img/GitExtensions-%D0%BD%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B0-diff.png)


