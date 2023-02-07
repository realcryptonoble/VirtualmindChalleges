function MultiplyBy() {
    console.log(mul(2)(3)(4));
    console.log(mul(4)(3)(4));
}

function mul(a) {
    return function (b) {
        return function (c) {
            return a * b * c;
        };
    };
}

function Longest_Country_Name(countries) {
    return country_name.reduce(function (lname, country) {
        return lname.length > country.length ? lname : country;}, "");
}

function insert_Row() {
    // Find a <table> element with id="myTable":
    var table = document.getElementById("myTable");

    // Create an empty <tr> element and add it to the 1st position of the table:
    var row = table.insertRow(0);

    // Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    // Add some text to the new cells:
    cell1.innerHTML = "NEW CELL1";
    cell2.innerHTML = "NEW CELL2";
}

function removecolor() {
    var x = document.getElementById("colorSelect");
    x.remove(x.selectedIndex);
}