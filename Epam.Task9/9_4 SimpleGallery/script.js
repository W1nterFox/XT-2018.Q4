var Timer;
var IsPause = false;
var IsStart = false;
var EndPage = 4;
var StartPage = 1;
var IsFirstConfirm = true;
var timeout = setTimeout(action, 10);

function start() {
    Timer = 300 * 1;
    action();
}

function action() {
    if (!IsStart) {
        IsStart = true;
        start();
    }

    Timer--;
    var pageName = location.href;
    pageName = pageName.substr(pageName.lastIndexOf("/") + 1);
    var numOfCurrentPage = pageName.match(/[0-9]+/) * 1;

    document.getElementById('time').innerHTML = Timer / 100;
    if (!IsPause) {
        timeout = setTimeout(action, 10);
    }       
    
    if (Timer < 1) {
        if (numOfCurrentPage != EndPage) {
            ToNextPage(GetNameOfNextPage);
        }
        else{
            if (IsFirstConfirm){
                var retVal = confirm("Do you want to continue scrolling gallery?");
                if( retVal == true ) {
                    location.assign("./" + "page" + StartPage + ".html");
                } 
                else {
                    var objWindow = window.open(location.href, "_self");
        objWindow.close();
                }

                IsFirstConfirm = false;
            }   
        }
    }
}

function GetNameOfNextPage() {
    var pageName = location.href;
    pageName = pageName.substr(pageName.lastIndexOf("/") + 1);
    var numberNextPage = pageName.match(/[0-9]+/) * 1 + 1;
    var mainPageName = pageName.substr(0, pageName.lastIndexOf(numberNextPage - 1));
    
    if (numberNextPage > EndPage) {
        return "./" + mainPageName + StartPage + ".html";
    }
    
    return "./" + mainPageName + (numberNextPage) + ".html";
}

function GetNameOfPreviousPage() {
    var pageName = location.href;
    pageName = pageName.substr(pageName.lastIndexOf("/") + 1);
    var numberPreviousPage = pageName.match(/[0-9]+/) * 1 - 1;
    if (numberPreviousPage < StartPage) {
        return "./" + mainPageName + EndPage + ".html";
    }
    var mainPageName = pageName.substr(0, pageName.lastIndexOf(numberNextPage - 1));
    return "./" + mainPageName + (numberPreviousPage) + ".html";
}

function ToNextPage() {
    location.assign(GetNameOfNextPage());
}


function ToPreviousPage() {
    history.back(GetNameOfPreviousPage);
}

function Pause() {
    if (!IsPause) {
        clearTimeout(timeout);
    }
    else {
        timeout = setTimeout(action, 10);
    }
    IsPause = !IsPause;
}