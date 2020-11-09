import { Component, OnInit } from "@angular/core";
import { FormControl, Validators, FormGroup } from "@angular/forms";
import { AuthService } from "../../services/auth.service";
import {
  SearchCountryField,
  TooltipLabel,
  CountryISO,
} from "ngx-intl-tel-input";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  phoneLoginForm: FormGroup;
  emailLoginForm: FormGroup;
  showEmailForm: boolean = true;

  SearchCountryField = SearchCountryField;
  TooltipLabel = TooltipLabel;
  CountryISO = CountryISO;
  preferredCountries: CountryISO[] = [
    CountryISO.UnitedStates,
    CountryISO.UnitedKingdom,
  ];

  constructor(private auth: AuthService) {}

  ngOnInit() {
    this.emailLoginForm = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"),
      ]),
    });

    this.phoneLoginForm = new FormGroup({
      phone: new FormControl(undefined, [Validators.required]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"),
      ]),
    });
  }

  get email() {
    return this.emailLoginForm.get("email");
  }

  get password() {
    return this.showEmailForm
      ? this.emailLoginForm.get("password")
      : this.phoneLoginForm.get("password");
  }

  get phone() {
    return this.phoneLoginForm.get("phone");
  }

  public login() {
    if (this.showEmailForm && (this.email.errors || this.password.errors)) {
      this.emailLoginForm.markAllAsTouched();
      return;
    }

    if (!this.showEmailForm && (this.phone.errors || this.password.errors)) {
      this.phoneLoginForm.markAllAsTouched();
      return;
    }

    const body = this.showEmailForm
      ? { email: this.email.value, password: this.password.value }
      : {
          password: this.password.value,
          phoneNumber: this.phone.value.internationalNumber,
          countryCode: this.phone.value.countryCode,
        };

    this.auth.login(body);
  }

  switchNabBlock(showEmailForm: boolean) {
    this.showEmailForm = showEmailForm;
    this.emailLoginForm.reset();
    this.phoneLoginForm.reset();
  }
}
