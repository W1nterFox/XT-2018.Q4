function removeDoubleChars() {
    text = document.getElementById("textArea").value
    var separators = [' ', '\t', '?', '!', ':', ';', ',', '.'];
    var str = text + "";
    var words;
    var result = str;
    var tempChar = separators[0];
    for (var i = 0; i < separators.length; i++) {
        str = str.split(separators[i]).join(tempChar);
    }
    words = str.split(tempChar);

    for (i = 0; i < words.length; i++) {
        for (var j = 0; j < words[i].length; j++) {
            for (var k = j + 1; k < words[i].length; k++) {
                if ((words[i][j] === words[i][k]) && (words[i].length > 1)) {
                    result = result.split(words[i][j]).join('');
                }
            }
        }
    }
    document.getElementById("resultOfRemove").innerHTML = result;
}