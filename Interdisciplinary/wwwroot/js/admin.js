console.log("Admin.js running...");

let state = 0;

function getFunky() {
    if (state == 0) {
        document.getElementById('funky').style.backgroundColor = "#32CD32";
        document.getElementById('funky').style.fontStyle = "italic";
        state = 1;
    } else {
        document.getElementById('funky').style.backgroundColor = "#FFFFFF";
        document.getElementById('funky').style.fontStyle = "normal";
        state = 0;
    }
}

//function passwordCheck() {
//
//    let pword = "";
//    console.log(pword);
//
//    if (document.querySelectorAll('input[type="password"]').value == pword) {
//        return true;
//    }
//    else {
//        // alert("Username and Password doesn't match.");
//        document.getElementById('error').innerHTML = "Username and Password doesn't match.";
//        return false;
//    }
//}
