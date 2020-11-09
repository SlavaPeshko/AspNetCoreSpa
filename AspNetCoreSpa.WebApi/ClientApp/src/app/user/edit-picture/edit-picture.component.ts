import { Component, OnInit } from "@angular/core";
import { ImageCroppedEvent } from "ngx-image-cropper";
import { FileService } from "../../services/file.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-edit-picture",
  templateUrl: "./edit-picture.component.html",
  styleUrls: ["./edit-picture.component.css"],
})
export class EditPictureComponent implements OnInit {
  fileUploaded: File = null;
  imageChangedEvent: any = "";
  croppedImage: any = "";
  imagePosition: any;
  isDownloadImage: boolean = false;

  constructor(private fileService: FileService, private router: Router) {}

  ngOnInit(): void {
    this.fileService.getUserPhoto().subscribe((response: any) => {
      debugger;
      this.imagePosition.x1 = response.position.x1;
      this.imagePosition.x2 = response.position.x2;
      this.imagePosition.y1 = response.position.y1;
      this.imagePosition.y2 = response.position.y2;

      this.fileUploaded = response.url;
    });
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
    formData.append("croppedImage", this.croppedImage);
    formData.append("file", this.fileUploaded);
    formData.append("x1", this.imagePosition.x1);
    formData.append("x2", this.imagePosition.x2);
    formData.append("y1", this.imagePosition.y1);
    formData.append("y2", this.imagePosition.y2);

    this.fileService.uploadUserImage(formData).subscribe((data) => {
      this.router.navigate(["/profile"]);
    });
  }
}
