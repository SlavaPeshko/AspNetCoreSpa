import { Component, OnInit } from "@angular/core";
import { FormControl, Validators, FormGroup } from "@angular/forms";
import { startTimer } from "../../helpers/timer";
import { SendingSmsType } from "../../models/SengingSmsType";
import {
  SearchCountryField,
  TooltipLabel,
  CountryISO,
} from "ngx-intl-tel-input";

@Component({
  selector: "app-phone-forgot",
  templateUrl: "./phone-forgot.component.html",
  styleUrls: ["./phone-forgot.component.css"],
})
export class PhoneForgotComponent implements OnInit {
  fogotForm: FormGroup;
  sendingSmsType: SendingSmsType = SendingSmsType.NONE;
  timeLeft: number = 5;
  verificationCode: number;
  firstSymbol: string;
  secondSymbol: string;
  thirdSymbol: string;
  fourthSymbol: string;

  SearchCountryField = SearchCountryField;
  TooltipLabel = TooltipLabel;
  CountryISO = CountryISO;
  preferredCountries: CountryISO[] = [
    CountryISO.UnitedStates,
    CountryISO.UnitedKingdom,
  ];

  constructor() {}

  ngOnInit(): void {
    this.fogotForm = new FormGroup({
      phone: new FormControl(undefined, [Validators.required]),
    });
    console.log(this.phone);
  }

  get phone() {
    return this.fogotForm.get("phone");
  }

  send() {
    console.log(this.phone);
    if (!this.canSendingSms()) return;

    this.sendingSmsType = SendingSmsType.TIMER;
    this.startTimer();
  }

  verify() {
    this.verificationCode = Number.parseInt(
      `${this.firstSymbol}${this.secondSymbol}${this.thirdSymbol}${this.fourthSymbol}`
    );
    console.log(this.verificationCode);
  }

  private startTimer() {
    const interval = setInterval(() => {
      if (this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.sendingSmsType = SendingSmsType.RESEND;
        this.timeLeft = 60;
        clearInterval(interval);
      }
    }, 1000);
  }

  private canSendingSms() {
    if (!this.phone.valid) return false;

    if (!this.phone.value) return false;

    if (this.sendingSmsType == SendingSmsType.TIMER) return false;

    return true;
  }
}
