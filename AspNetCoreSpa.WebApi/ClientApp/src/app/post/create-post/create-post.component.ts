import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post.service';
import { FileService } from '../../services/file.service';
import { Post } from 'src/app/models/post';
import { config } from '../../config';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {
  message: string = '';
  files: any[] = [];

  constructor(private postService: PostService,
    private fileService: FileService,) { }

  ngOnInit(): void {
  }

  confirmText(value: string) {
    this.message = value;
  }

  handleFileInput(files: any) {
    if(!files && !files[0])
      return;

    const file = files[0];
    file.progress = 0;
    this.files.push(files[0]);
    this.uploadFilesSimulator(0);
  }

  uploadFilesSimulator(index: number) {
    setTimeout(() => {
      if (index === this.files.length) {
        return;
      } else {
        const progressInterval = setInterval(() => {
          if (this.files[index].progress === 100) {
            clearInterval(progressInterval);
            this.uploadFilesSimulator(index + 1);
          } else {
            this.files[index].progress += 5;
          }
        }, 200);
      }
    }, 1000);
  }

  deleteFile(index: number){
    this.files.splice(index, 1);
  }

  formatBytes(bytes, decimals) {
    if (bytes === 0) {
      return '0 Bytes';
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }

  cancel(){
    debugger;
  }

  post() {
    const post: Post = new Post();
    post.description = this.message;

    this.postService.create(post).subscribe(data=> {
      if(!this.files && this.files.length === 0)
        return;
      
      let formData: FormData = new FormData();
      for (let i = 0; i < this.files.length; i++) {
        const item = this.files[i];
        formData.append('images', item, item.name);
      }

      const url = `${config.apiUrl}/${config.endpoint.post}/${data.id}/images`;
      this.fileService.uploadImages(formData, url).subscribe(data => {});
    });
  }

  canPost() {
    return this.message.length > 0 ? true : false;
  }
}
