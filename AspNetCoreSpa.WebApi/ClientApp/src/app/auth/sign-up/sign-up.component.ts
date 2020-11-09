import { Component, OnInit } from "@angular/core";
import { FormControl, Validators, FormGroup } from "@angular/forms";
import { User_Validation_Message } from "../user_validation_message";
import { UserService } from "../../services/user.service";
import { SmsService } from "../../services/sms.serive";
import { Router } from "@angular/router";
import {
  SearchCountryField,
  TooltipLabel,
  CountryISO,
} from "ngx-intl-tel-input";
import { PhoneNumber } from "src/app/models/phoneNumber";
import { SendingSmsType } from "../../models/SengingSmsType";

@Component({
  selector: "app-sign-up",
  templateUrl: "./sign-up.component.html",
  styleUrls: ["./sign-up.component.css"],
})
export class SignUpComponent implements OnInit {
  emailSignUpFormGroup: FormGroup;
  phoneSignUpFormGroup: FormGroup;
  showEmailForm: boolean = true;
  user_validation_message: any;
  SearchCountryField = SearchCountryField;
  TooltipLabel = TooltipLabel;
  CountryISO = CountryISO;
  preferredCountries: CountryISO[] = [
    CountryISO.UnitedStates,
    CountryISO.UnitedKingdom,
  ];
  timeLeft: number = 60;
  statusSendingSms: SendingSmsType = SendingSmsType.NONE;

  constructor(
    private userService: UserService,
    private smsService: SmsService,
    private router: Router
  ) {
    this.user_validation_message = User_Validation_Message;
  }

  ngOnInit() {
    this.emailSignUpFormGroup = new FormGroup({
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"),
      ]),
    });

    this.phoneSignUpFormGroup = new FormGroup({
      phone: new FormControl(undefined, [Validators.required]),
      verificationCode: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(4),
      ]),
      password: new FormControl("", [
        Validators.required,
        Validators.pattern("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$"),
      ]),
    });
  }

  get email() {
    return this.emailSignUpFormGroup.get("email");
  }

  get password() {
    return this.showEmailForm
      ? this.emailSignUpFormGroup.get("password")
      : this.phoneSignUpFormGroup.get("password");
  }

  get phone() {
    return this.phoneSignUpFormGroup.get("phone");
  }

  get verificationCode() {
    return this.phoneSignUpFormGroup.get("verificationCode");
  }

  create() {
    debugger;
    if (this.showEmailForm && (this.password.errors || this.email.errors)) {
      this.emailSignUpFormGroup.markAllAsTouched();
      return;
    }

    if (!this.showEmailForm && (this.phone.errors || this.password.errors)) {
      this.phoneSignUpFormGroup.markAllAsTouched();
      return;
    }

    const body = this.showEmailForm
      ? { email: this.email.value, password: this.password.value }
      : {
          password: this.password.value,
          phoneNumber: this.phone.value.internationalNumber,
          countryCode: this.phone.value.countryCode,
        };

    this.userService.create(body).subscribe(() => {
      this.router.navigate(["/login"]);
    });
  }

  switchNabBlock(showEmailForm: boolean) {
    this.showEmailForm = showEmailForm;
    this.emailSignUpFormGroup.reset();
    this.phoneSignUpFormGroup.reset();
  }

  sendSms() {
    if (this.showEmailForm) return;

    if (this.canSendSms()) return;

    const phoneNumber: PhoneNumber = {
      PhoneNumber: this.phone.value.internationalNumber,
      CountryCode: this.phone.value.countryCode,
    };

    this.smsService.sendSms(phoneNumber).subscribe(() => {
      this.statusSendingSms = SendingSmsType.TIMER;
      this.startTimer();
    });
  }

  private startTimer() {
    const interval = setInterval(() => {
      if (this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.statusSendingSms = SendingSmsType.RESEND;
        this.timeLeft = 60;
        clearInterval(interval);
      }
    }, 1000);
  }

  private canSendSms() {
    return (
      !this.phone.valid ||
      !this.phone.value ||
      this.statusSendingSms == SendingSmsType.TIMER
    );
  }
}
