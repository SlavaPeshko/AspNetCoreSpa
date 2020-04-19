import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreatePostComponent } from './create-post/create-post.component';



@NgModule({
  declarations: [CreatePostComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PostModule { }
