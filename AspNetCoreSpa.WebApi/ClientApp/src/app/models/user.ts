import { Gender } from '../models/gender';
import { Image } from '../models/image';
import { Address } from '../models/address';

export class User {
    id: number;
    email: string;
    phone: string;
    password: string;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    gender: number;
    address: Address;
    image: Image;
}