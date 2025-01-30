import { Component, OnInit } from '@angular/core';
import { MomentService } from 'src/app/services/moment.service';
import { MessagesService } from 'src/app/services/messages.service';
import { Moment } from 'src/app/interface-moment';
import { Router, ActivatedRoute } from '@angular/router';
import { CommentService } from 'src/app/services/comment.service';
import { environment } from 'src/environments/environment';

import { faTimes, faEdit } from '@fortawesome/free-solid-svg-icons';

import { Comment } from 'src/app/interface-comment';

import { FormGroup, FormControl, Validators, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-moment',
  templateUrl: './moment.component.html',
  styleUrls: ['./moment.component.css']
})
export class MomentComponent implements OnInit {
  moment?: Moment;
  baseApiUrl = environment.baseApiUrl;
  faTimes = faTimes;
  faEdit = faEdit;
  
  commentForm!: FormGroup; // nao esta inicialuizado, mas a ENTIDADE existe


  constructor(
    private momentService: MomentService, 
    private route: ActivatedRoute,
    private messageService: MessagesService,
    private router: Router,
    private commentService: CommentService,
  ) { }

  ngOnInit(): void {
    // pegando ida que esta na url
    const id = Number(this.route.snapshot.paramMap.get("id"));
    this.momentService.getMoment(id).subscribe( (item) => this.moment = item.data);

    this.commentForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      text: new FormControl("", [Validators.required]),
    })

  }

  async removeHandler(id: number){
    await this.momentService.removeMoment(id).subscribe({
      next:() =>{
        this.messageService.add("Momento excluído com sucesso");
        this.router.navigate(['/']);
      }
    })

  }

  get username(){
    return this.commentForm.get('username')!
  }

  get text(){
    return this.commentForm.get('text')!
  }

  async onSubmit(formDirective: FormGroupDirective){
    if(this.commentForm.invalid){
      return
    }
    const data: Comment = this.commentForm.value;
    data.momentId = Number(this.moment!.id)

    await this.commentService.createComment(data).subscribe((comment) => this.moment!.comments!.push(comment.data))

    this.messageService.add("Comentário adicionado");
    this.commentForm.reset();
    formDirective.resetForm();
  }
}
