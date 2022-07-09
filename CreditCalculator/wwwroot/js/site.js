let myFirstBtn = document.getElementById('js-validation');
let inputLoanAmount = document.getElementById('LoanAmount'),
    inputTerm = document.getElementById('MonthlyTerm'),
    inputRate = document.getElementById('AnnualInterestRate'),
    formInputs = document.querySelectorAll('.form-control'),
    form = document.querySelectorAll('.js-form');

let errorMsg = document.getElementsByClassName('error');

inputLoanAmount.addEventListener('input', function (e) {
    inputLoanAmount.value = inputLoanAmount.value.replace('.', ',');
})

function validateMoney (money) {
    let regexMoney = /^\d+(?:,\d{1,2})?$/;
    return regexMoney.test(money)
}

myFirstBtn.addEventListener('click', function (e) {
    e.preventDefault();
    
    let loanAmountValue = inputLoanAmount.value,
        termValue = inputTerm.value,
        rateValue = inputRate.value,
        emptyInputs = Array.from(formInputs).filter(input => input.value === '');

    document.getElementById('LoanAmount').value = inputLoanAmount.value.replace('.', ',');

    formInputs.forEach(function (input) {
        if (input.value === '') {
            input.classList.add('is-invalid');
        }
    });

    // if (emptyInputs.length !== 0) {
    //     e.preventDefault();
    // }
    
    if (!validateMoney(loanAmountValue)) {
        inputLoanAmount.classList.add('is-invalid');
        console.log('валидация по денюжке не сработала');
        inputLoanAmount.setCustomValidity('invalid');
    } else {
        console.log('денежкииии');
    }
    
    
});

