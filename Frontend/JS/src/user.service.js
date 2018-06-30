import { user } from './user.js';

function showMessage() {
    alert('Hello ' + user.name);
}

export function confirmAge() {
    var age = prompt("What's your age?");
    if (age >= 18) {
        showMessage();
    }
    else {
        window.location.href = "https://www.youtube.com/watch?v=OK03o3BHafk";
    }
}

function filterArray(numbers, min, max) {

    var newArray = [];
    numbers.forEach(element => {
        if (element >= min && element <= max) {
            newArray.push(element);
        }
    });
    return newArray;
}
function isEmpty(obj) {
    for (var i in obj) {
        if (obj.hasOwnProperty(i)) {
            return false;
        }
    }
    return true;
}

function GetKeys(obj) {
    var array = [];
    for (var key in obj) {
        array.push(key)
    }
    return array;
}
export function main() {
    var value = 0;
    var array = [];
    while (value < 10) {
        array.push(value++);
    }
    console.log(array);
    console.log(filterArray(array, 3, 7));

    var user1 = { name: "Alex", age: 21 };
    var user2 = {};
    console.log(isEmpty(user1));
    console.log(isEmpty(user2));

    console.log(GetKeys(user1));
}
