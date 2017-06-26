function LimtCharacters(txtMsg, CharLength, indicator) {
    chars = txtMsg.value.length;
    document.getElementById(indicator).innerHTML = CharLength - chars;
    if (chars > CharLength) {
        txtMsg.value = txtMsg.value.substring(0, CharLength);
    }
}