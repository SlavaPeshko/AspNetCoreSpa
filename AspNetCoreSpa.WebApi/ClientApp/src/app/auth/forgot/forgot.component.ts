import { Component, OnInit } from "@angular/core";
import {
  FormControl,
  Validators,
  FormGroup,
  ValidatorFn,
  ValidationErrors,
} from "@angular/forms";
import { UserService } from "../../services/user.service";
import { ActivatedRoute, Router } from "@angular/router";
import {
  checkPasswordsValidator,
  passwordConfirming,
} from "../../shared/check-password.directive";

@Component({
  selector: "app-forgot",
  templateUrl: "./forgot.component.html",
  styleUrls: ["./forgot.component.css"],
})
export class ForgotComponent implements OnInit {
  emailForm: FormGroup;
  forgotForm: FormGroup;
  emailFromToken: string;
  isSendEmail: boolean = false;
  showResetPasswordForm: boolean = true;

  constructor(
    private userService: UserService,
    private activetedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.activetedRoute.queryParams.subscribe((params) => {
      const token = params["token"];
      if (token) {
        this.forgotForm = new FormGroup(
          {
            password: new FormControl("", [
              Validators.required,
              Validators.pattern(
                "(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"
              ),
            ]),
            confirmPassword: new FormControl("", Validators.required),
          },
          { validators: passwordConfirming }
        );

        this.userService.validateToken(token).subscribe((response: any) => {
          this.emailFromToken = response.data;
          this.showResetPasswordForm = true;
        });
      } else {
        this.emailForm = new FormGroup({
          email: new FormControl("", [Validators.required, Validators.email]),
        });
        this.showResetPasswordForm = false;
      }
    });
  }

  get email() {
    return this.emailForm.get("email");
  }

  get password() {
    return this.forgotForm.get("password");
  }

  get confirmPassword() {
    return this.forgotForm.get("confirmPassword");
  }

  send() {
    if (this.email.errors) {
      this.emailForm.markAllAsTouched();
    }

    this.userService.sendEmail(this.email.value).subscribe(() => {
      this.isSendEmail = true;
    });
  }

  forgotPassword() {
    if (this.forgotForm.errors) {
      this.forgotForm.markAllAsTouched();
    }

    this.userService.forgotPassword({password: this.password.value, email: this.emailFromToken})
    .subscribe(() => {this.router.navigate(["/login"]);});
  }
}
