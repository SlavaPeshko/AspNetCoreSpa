import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CountryService } from '../../services/country.service';
import { User } from '../../models/user';
import { Country } from '../../models/country';
import { Jwt } from '../../helpers/jwt';
import { Gender } from '../../models/gender';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public fileUploaded: File = null;
  public url: any = null;
  public countries: Country[];
  public selectedCountry: Country = null;
  public user: User;
  public userId: string;
  public genderNames = Object.values(Gender).filter(e => typeof(e) == "string");
  public model: NgbDateStruct;

  constructor(private userService: UserService,
     private jwt: Jwt,
     private countryService: CountryService) {
   }

  ngOnInit() {
    this.userId = this.jwt.getUserId();

    this.userService.getById(this.userId).subscribe(data => {
      this.user = data;
      this.setDate();
    });

    this.countryService.get().subscribe(data => {
      this.countries = data;
    })
  }

  private setDate() {
    const date = new Date(this.user.dateOfBirth);

    const year = date.getFullYear();
    const month = date.getMonth() + 1;
    const day = date.getDate();

    this.model = { year, month, day };
  }

  public update() {
    if(this.selectedCountry){
      this.user.countryId = this.selectedCountry.id;
    }

    //4/7/2018Z
    this.user.dateOfBirth = new Date(`${this.model.month}/${this.model.day}/${this.model.year}Z`).toISOString();

    this.userService.update(this.user).subscribe(data=> {
    })
  }

  handleFileInput(files: FileList){
    if(!files && !files[0])
      return;

    this.fileUploaded = files[0];

    this.setUrl(this.fileUploaded);
  }

  onRadioChange(item: Gender){
    this.user.gender = item;
  }

  private setUrl(file: File){
    let reader = new FileReader();
    reader.readAsDataURL(file);

    reader.onload = (event: Event) => {
      this.url = reader.result;
    }
  }
}
