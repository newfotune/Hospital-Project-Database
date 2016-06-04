
/*window.onload = function(){
    var aProperty;
    document.write("Navigator Object Properties<br /> ");

    for (aProperty in navigator) {
        if (aProperty == "onLine" || aProperty.includes("product")) {
            document.write(aProperty);
            document.write("<br />");
        }
    }
    document.write("Exiting from the loop! <br /><br /><br />");

    var name = concatnate("Fortune", "Nwoke");
    document.write(name);
}*/

function concatnate(fname, lname) {
   return fname + ", " + lname;
}

function reverse() {
    var theWord = document.getElementById("area").nodeValue;

    document.getElementById("answer").nodeValue = theWord;
   
       
}
