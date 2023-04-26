function getManchesterLevelEncoding(bits) {
    var result = [];
    for (var i = 0; i < bits.length; i++) {
        let symbol = '⚋⚋';
        if (parseInt(bits[i].value) == 1) symbol = '▁∣▔';
        if (parseInt(bits[i].value) == 1 && i > 0 && parseInt(bits[i - 1].value) == 1) symbol = '∣▁∣▔';
        if (parseInt(bits[i].value) == 0) symbol = '▔∣▁';
        if (parseInt(bits[i].value) == 0 && i > 0 && parseInt(bits[i - 1].value) == 0) symbol = '∣▔∣▁';
        result.push(symbol);
    }
    return result;
}

// NRZ-L - non return to zero level
// 1 - codificat pe nivelul high pe durata perioadei
// 0 - codificat pe nivelul low pe durata perioadei
function getNRZLLevelEncoding(bits) {
    var result = [];
    for (var i = 0; i < bits.length; i++) {
        let symbol = '⚋⚋';
        if (parseInt(bits[i].value) == 1) symbol = '▁∣▔';
        if (parseInt(bits[i].value) == 1 && i > 0 && parseInt(bits[i - 1].value) == 1) symbol = '∣▁∣▔';
        if (parseInt(bits[i].value) == 0) symbol = '▔∣▁';
        if (parseInt(bits[i].value) == 0 && i > 0 && parseInt(bits[i - 1].value) == 0) symbol = '∣▔∣▁';
        result.push(symbol);
    }
    return result;
}

// NRZ-M - non return to zero mark
// 1 - produce o tranzitie la inceputul perioadei
// 0 - pastreaza nivelul
function getNRZLLevelEncoding(bits) {
    var result = [];
    for (var i = 0; i < bits.length; i++) {
        let symbol = '⚋⚋'; check = 0;
        if (parseInt(bits[i].value) == 1 && check == 0) {
          symbol = '▁∣▔';
          check = 1; // the signal is on HIGH
        }
        if (parseInt(bits[i].value) == 1 && check == 1) {
          symbol = '▔∣▁';
          check = 0; // the signal is on LOW
        }
        if (parseInt(bits[i].value) == 0 &&  check == 1) symbol = '▔▔';
        if (parseInt(bits[i].value) == 0 && check == 0) symbol = '__';
        result.push(symbol);
    }
    return result;
}

// NRZ-S - non return to zero space
// 0 - produce o tranzitie la inceputul perioadei
// 1 - pastreaza nivelul
function getNRZLLevelEncoding(bits) {
    var result = [];
    for (var i = 0; i < bits.length; i++) {
        let symbol = '⚋⚋'; check = 0;
        if (parseInt(bits[i].value) == 0 && check == 0) {
          symbol = '▁∣▔';
          check = 1; // the signal is on HIGH
        }
        if (parseInt(bits[i].value) == 0 && check == 1) {
          symbol = '▔∣▁';
          check = 0; // the signal is on LOW
        }
        if (parseInt(bits[i].value) == 1 &&  check == 1) symbol = '▔▔';
        if (parseInt(bits[i].value) == 1 && check == 0) symbol = '__';
        result.push(symbol);
    }
    return result;
}

// RZ - return to zero
function getRZLevelEncoding(bits) {
    var result = [];
    return result;
}

// PE - phase encoded / split phase
function getPELevelEncoding(bits) {
    var result = [];
    return result;
}

// MLB - multilevel binary
function getMLBLevelEncoding(bits) {
    var result = [];
    return result;
}
