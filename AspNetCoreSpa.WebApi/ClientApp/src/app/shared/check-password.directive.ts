import {
  FormGroup,
  ValidatorFn,
  ValidationErrors,
  NG_VALIDATORS,
  Validator,
  AbstractControl,
} from "@angular/forms";
import { Directive } from "@angular/core";

export const checkPasswordsValidator: ValidatorFn = (
  formGroup: FormGroup
): ValidationErrors | null => {
  const password = formGroup.get("password");
  const confirmPassword = formGroup.get("confirmPassword");

  return password && confirmPassword && password.value == confirmPassword.value
    ? { notSame: true }
    : null;
};

export function passwordConfirming(
  control: AbstractControl
): { invalid: boolean } {
  if (control.get("password").value !== control.get("confirmPassword").value) {
    return { invalid: true };
  }
}

@Directive({
  selector: "[appCheckPassword]",
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: CheckPasswordsValidatorDirective,
      multi: true,
    },
  ],
})
export class CheckPasswordsValidatorDirective implements Validator {
  validate(control: AbstractControl): ValidationErrors {
    return checkPasswordsValidator(control);
  }
}
