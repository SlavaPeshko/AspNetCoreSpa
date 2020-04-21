import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreatePostComponent } from './create-post/create-post.component';
import { PostsComponent } from './posts/posts.component';



@NgModule({
  declarations: [CreatePostComponent, PostsComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PostModule { }
