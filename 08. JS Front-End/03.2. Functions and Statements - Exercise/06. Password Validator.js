function passwordValidator(password){

    const isValidLength = password => password.length >= 6 && password.length <= 10;
    const isLettersAndDigits = password => /^[A-Za-z0-9]+$/.test(password);
    const isTwoDigits = password => password
            .split('')
            .filter(char =>Number.isInteger(Number(char)))
            .length >=2;
    
    const validations = [
        [isValidLength,'Password must be between 6 and 10 characters'],
        [isLettersAndDigits,'Password must consist only of letters and digits'],
        [isTwoDigits,'Password must have at least 2 digits'],
    ]

    const validPassword = 'Password is valid';

    const errors = validations
        .map(([validator,message])=>validator(password)?'':message)
        .filter(message => !!message);
    
    (errors.length === 0)?
        console.log(validPassword):
        errors.forEach(message=>console.log(message));
}

passwordValidator('login');