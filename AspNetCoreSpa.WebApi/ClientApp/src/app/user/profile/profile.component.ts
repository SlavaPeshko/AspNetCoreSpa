import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CountryService } from '../../services/country.service';
import { User } from '../../models/user';
import { Country } from '../../models/country';
import { Jwt } from '../../helpers/jwt';
import { Gender } from '../../models/gender';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public fileUploaded: File = null;
  public url: any = null;
  public countries: Country[];
  public selectedCountryName: Country;
  public user: User;
  public userId: string;
  public genderNames = Object.values(Gender).filter(e => typeof(e) == "string");

  constructor(private userService: UserService,
     private jwt: Jwt,
     private countryService: CountryService) {
   }

  ngOnInit() {
    this.userId = this.jwt.getUserId();

    this.userService.getById(this.userId).subscribe(data => {
      this.user = data;
    });

    this.countryService.get().subscribe(data => {
      this.countries = data;
    })
  }

  public save() {
    debugger;
    this.userService.update(this.user).subscribe(data=> {
      console.log(data);
    })
  }

  onItemChange(item){
    debugger;
    item = !item;
  }

  updateWorkout(event){
    debugger;
    this.user.country = this.countries.find(x => x.name === event);
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
