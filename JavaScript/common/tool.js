

let timeA = new Date().getTime();

var getTime = () => {
    timeA = new Date().getTime();
    return timeA;
};

var getTimeB = () => new Date().getTime();


var logTime = () => console.log(getTimeB() - timeA);