let id = (id) => document.getElementById(id),
    classes = (classes) => document.getElementsByClassName(classes);

let form = id("form"),
    loanAmount = id("LoanAmount"),
    term = id("MonthlyTerm"),
    rate = id("AnnualInterestRate"),
    errorMsg = classes("error");

let currentEvent;

replacingSeparator(loanAmount);
replacingSeparator(rate);

function replacingSeparator(input) {
    input.addEventListener("input", () => {
        input.value = input.value.replace(".", ",");
    })
}


form.addEventListener("submit", (event) => {
    currentEvent = event;

    validateMoney(loanAmount, 0);
    validateTerm(term, 1);
    validateRate(rate, 2);

    checkErrors();
});

function isBlankInput(input, index) {
    if (input.value.trim() === "") {
        setInvalidType(input, index, "Ну чего такой жадный, не оставляй поле пустым...");
        return true;
    } else {
        setValidType(input, index);
        return false;
    }
}

function validateMoney(input, index) {
    
    if (isBlankInput(input, index)) {
        return ;
    }
    
    // введенное значение должно быть числом с 2 значащими цифрами после запятой
    let regexMoney = /^\d+(?:,\d{1,2})?$/;
    const max = 99999999999.99;
    const min = 0;

    if (!regexMoney.test(input.value)) {
        setInvalidType(input, index, `Недопустимый формат. Введи так, чтобы это было похоже на деньги)`);
    } else {
        let moneyValue = parseFloat(input.value.replace(',', '.'));
        if (moneyValue <= min)
            setInvalidType(input, index, `Введи сумму больше ${min}. Или совсем денег не хочешь?`);
        if (moneyValue > max)
            setInvalidType(input, index, `Слишком большая сумма. Ты ее никогда не выплатишь...`);
    }
}

function validateTerm(input, index) {
    
    if (isBlankInput(input, index)) {
        return ;
    }
    
    // введенное значение должно быть целочисленным числом
    let regexTerm = /^\d+$/;
    const max = 1200;
    const min = 0;

    if (!regexTerm.test(input.value)) {
        setInvalidType(input, index, `Недопустимый формат. Введи так, чтобы это было похоже на кол-во месяцев)`);
    } else {
        let termValue = parseInt(input.value);
        if (termValue <= min)
            setInvalidType(input, index, `Введи сумму больше ${min}. Срок займа слишком маленький.`);
        if (termValue > max)
            setInvalidType(input, index, `Срок займа ${Math.floor(termValue / 12)} лет, серьезно? Ты ж помрешь быстрее...`);
    }
}

function validateRate(input, index) {

    if (isBlankInput(input, index)) {
        return ;
    }
    
    // введенное значение должно быть числом с 3 значащими цифрами после запятой
    let regexRate = /^\d+(?:,\d{1,3})?$/;
    const max = 365;
    const min = 0;

    if (!regexRate.test(input.value)) {
        setInvalidType(input, index, `Недопустимый формат. Введи так, чтобы это было похоже на %)`);
    } else {
        let rateValue = parseFloat(input.value.replace(',', '.'));
        if (rateValue <= min)
            setInvalidType(input, index, `Введи сумму больше ${min}. Мне же надо как-то проценты начислять)`);
        if (rateValue > max)
            setInvalidType(input, index, `Слишком большая сумма. Введи значение меньше ${max}`);
    }
}

function setInvalidType(input, index, msg) {
    if (input.classList.contains("is-valid"))
        input.classList.remove("is-valid");

    if (!input.classList.contains("is-invalid"))
        input.classList.add("is-invalid");

    errorMsg[index].innerHTML = msg + '<br/>';
}

function setValidType(input, index) {
    if (input.classList.contains("is-invalid")) {
        input.classList.remove("is-invalid");
        errorMsg[index].innerHTML = "";
    }

    if (!input.classList.contains("is-valid"))
        input.classList.add("is-valid");
}

function checkErrors() {
    for (let i = 0; i < errorMsg.length; i++) {
        //Если нет сообщения об ошибке - шагаем дальше
        if (errorMsg[i].innerHTML === "") continue;

        currentEvent.preventDefault();
        return true;
    }

    return false;
}
    