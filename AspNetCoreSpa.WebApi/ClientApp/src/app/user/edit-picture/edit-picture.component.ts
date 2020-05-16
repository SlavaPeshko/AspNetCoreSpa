import { Component, OnInit } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { FileService } from '../../services/file.service';

@Component({
  selector: 'app-edit-picture',
  templateUrl: './edit-picture.component.html',
  styleUrls: ['./edit-picture.component.css']
})
export class EditPictureComponent implements OnInit {
  fileUploaded: File = null;
  imageChangedEvent: any = '';
  croppedImage: any = '';
  imagePosition:any;
  isDownloadImage: boolean = false;

  constructor(private fileService: FileService) { }

  ngOnInit(): void {
  }

  fileChangeEvent(event: any): void {
    this.fileUploaded = event.target.files[0];
    this.imageChangedEvent = event;
    this.isDownloadImage = true;
  }
  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
    this.imagePosition = event.imagePosition;
  }
  imageLoaded() {
    // show cropper
  }
  cropperReady() {
    // cropper ready
  }
  loadImageFailed() {
    // show message
  }

  save() {
    let formData: FormData = new FormData();
    formData.append('cropped', this.croppedImage)
    formData.append('file', this.fileUploaded);
    formData.append('x1', this.imagePosition.x1);
    formData.append('x2', this.imagePosition.x2);
    formData.append('y1', this.imagePosition.y1);
    formData.append('y2', this.imagePosition.y2);

    this.fileService.uploadUserImage(formData)
      .subscribe(data => {
        debugger;
      })
  }

}
