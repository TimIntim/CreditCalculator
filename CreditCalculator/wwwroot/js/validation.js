let id = (id) => document.getElementById(id),
    classes = (classes) => document.getElementsByClassName(classes);

let form = id("form"),
    loanAmount = id("LoanAmount"),
    term = id("MonthlyTerm"),
    rate = id("AnnualInterestRate"),
    formInputs = document.querySelectorAll('.form-control'),
    errorMsg = classes("error");

let currentEvent;

replacingSeparator(loanAmount);
replacingSeparator(rate);

function replacingSeparator (input) {
    input.addEventListener("input", () => {
        input.value = input.value.replace(".", ",");
    })
}

form.addEventListener("submit", (event) => {
    currentEvent = event;
    
    if (checkForBlankInputs()) return false;
    if (validateMoney(loanAmount, 0)) return false;
    
});

function checkForBlankInputs() {
    for (let i = 0; i < formInputs.length; i++) {
        let input = formInputs[i];
        if (input.value.trim() === "") {
            setInvalidType(input, i, "Ну чего такой жадный, не оставляй поле пустым...");
        } else {
            setValidType(input, i);
        }
    }
    
    return checkErrors();
}

function validateMoney (input, index) {
    let regexMoney = /^\d+(?:,\d{1,2})?$/;
    if (!regexMoney.test(input.value)) {
        setInvalidType(input, index, "Недопустимый формат. Введи так, чтобы это было похоже на деньги)")
    }
    
    return checkErrors();
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

function setInvalidType(input, index ,msg) {
    if (input.classList.contains("is-valid"))
        input.classList.remove("is-valid");

    if (!input.classList.contains("is-invalid"))
        input.classList.add("is-invalid");

    errorMsg[index].innerHTML = msg + '<br/>';
}

function setValidType(input, index) {
    if (input.classList.contains("is-invalid")){
        input.classList.remove("is-invalid");
        errorMsg[index].innerHTML = "";
    }

    if (!input.classList.contains("is-valid"))
        input.classList.add("is-valid");
}
    