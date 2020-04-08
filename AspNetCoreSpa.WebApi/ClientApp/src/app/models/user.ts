import { Country } from '../models/country';
import { Gender } from '../models/gender';
import { Image } from '../models/image';

export class User {
    id: string;
    email: string;
    phone: string;
    password: string;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    gender: Gender;
    countryId: string;
    country: Country;
    image: Image;
}