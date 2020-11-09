import { Component, OnInit } from "@angular/core";
import { UserService } from "../../services/user.service";
import { FileService } from "../../services/file.service";
import { CountryService } from "../../services/country.service";
import { User } from "../../models/user";
import { Country } from "../../models/country";
import { Jwt } from "../../helpers/jwt";
import { Gender } from "../../models/gender";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { config } from "../../config";
import { Address } from "src/app/models/address";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  public fileUploaded: File = null;
  public url: any = null;
  public countries: Country[];
  public selectedCountry: Country = null;
  public user: User;
  public address: Address;
  public userId: number;
  public genders: any = [];
  public model: NgbDateStruct;

  constructor(
    private userService: UserService,
    private jwt: Jwt,
    private countryService: CountryService,
    private fileService: FileService
  ) {
    this.fillArrayFromEnum(Gender, this.genders);
  }

  ngOnInit() {
    this.userId = this.jwt.getUserId();

    this.userService.getById(this.userId).subscribe((data) => {
      this.user = data;
      this.address = data.address == null ? new Address() : data.address;

      this.setDate();
    });

    this.countryService.get().subscribe((data) => {
      this.countries = data;
    });
  }

  private setDate() {
    const date = new Date(this.user.dateOfBirth);

    // default data
    if (date.valueOf() == -62135603416000) return;

    const year = date.getFullYear();
    const month = date.getMonth() + 1;
    const day = date.getDate();

    this.model = { year, month, day };
  }

  public update() {
    if (this.selectedCountry) {
      this.address.countryId = this.selectedCountry.id;
      this.address.countryname = this.selectedCountry.name;
    }

    if (this.model) {
      this.user.dateOfBirth = new Date(
        `${this.model.month}/${this.model.day}/${this.model.year}Z`
      ).toISOString();
    }

    this.user.address = { ...this.address };
    this.userService.update(this.user).subscribe(() => {});

    this.uploadPhoto();
  }

  handleFileInput(files: FileList) {
    if (!files && !files[0]) return;

    this.fileUploaded = files[0];

    this.setUrl(this.fileUploaded);
  }

  onRadioChange(item: number) {
    this.user.gender = item;
  }

  profileImageUrl() {
    if (this.url) return this.url;

    if (!this.user && !this.user.image) return;

    return this.user.image.url;
  }

  private setUrl(file: File) {
    let reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = (event: Event) => {
      this.url = reader.result;
    };
  }

  private fillArrayFromEnum<Enum>(item: Enum, array: [{}]) {
    for (const key in item) {
      if (isNaN(Number(key))) continue;

      const object = { id: key, name: item[key] };
      array.push(object);
    }
  }

  private uploadPhoto() {
    if (!this.fileUploaded) return;

    const url = `${config.apiUrl}/${config.endpoint.user.uploadProfileImage}`;

    let formData: FormData = new FormData();
    formData.append("file", this.fileUploaded, this.fileUploaded.name);

    this.fileService.uploadImages(formData, url).subscribe((data) => {});
  }
}
