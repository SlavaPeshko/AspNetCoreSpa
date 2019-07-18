export const User_Validation_Message: any = {
    'firstName': [
        { type: 'required', message: 'First name is required' },
        { type: 'minlength', message: 'First name  must be at least 8 characters long' },
        { type: 'maxlength', message: 'First name  cannot be more than 25 characters long' },
    ],
    'lastName': [
        { type: 'required', message: 'Last name is required' },
        { type: 'minlength', message: 'Last name  must be at least 5 characters long' },
        { type: 'maxlength', message: 'Last name  cannot be more than 25 characters long' },
    ],
    'emailOrPhone': [
        { type: 'required', message: 'Email or pheon is required' },
    ],
    'password': [
        { type: 'required', message: 'Password is required' },
        { type: 'minlength', message: 'Password must be at least 8 characters long' },
        { type: 'pattern', message: 'Your password must contain at least one uppercase, one lowercase, and one number' }
    ],
    'confirm_password': [
        { type: 'required', message: 'Confirm password is required' },
        { type: 'areEqual', message: 'Password mismatch' }
    ],
    'birthDay': [
        { type: 'required', message: 'BirthDay is required' },
    ]
}