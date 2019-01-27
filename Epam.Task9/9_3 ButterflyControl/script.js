function moveOptionItem(event) {
    let target = event.target;
    if (!target.matches('.moveItem')) {
        return;
    }

    const selectedOption = -1;
    let currentMenu = target.closest('.container');
    let leftOptionsField = currentMenu.querySelector('.left select');
    let rightOptionsField = currentMenu.querySelector('.right select');

    let moveFrom = leftOptionsField;
    let moveTo = rightOptionsField;

    if (target.dataset.moveLeft != undefined) {
        moveFrom = rightOptionsField;
        moveTo = leftOptionsField;
    }

    let optionsToMove = moveFrom.querySelectorAll('option' + (target.dataset.all != undefined ? '' : ':checked'));

    for (let option of optionsToMove) {
        moveTo.append(option);
    }

    moveTo.selectedIndex = selectedOption;
}

(function () {
    window.onload = function () {
        document.querySelector('.container').addEventListener('click', moveOptionItem);
    }
})();