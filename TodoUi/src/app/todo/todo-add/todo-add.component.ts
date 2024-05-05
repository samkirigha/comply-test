import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, DestroyRef, inject } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { ButtonModule } from 'primeng/button';
import { TodoService } from '../todo.service';
import { Todo } from '../todo.model';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-todo-add',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    InputTextModule,
    InputTextareaModule,
    ButtonModule
  ],
  templateUrl: './todo-add.component.html',
  styleUrl: './todo-add.component.scss',
  providers: [TodoService]
})
export class TodoAddComponent {

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    description: new FormControl(''),
  });
  isSubmitting: boolean = false;

  private destroyRef$ = inject(DestroyRef);

  constructor(private todoService: TodoService, public dialogRef: DynamicDialogRef) { }

  submit(): void {
    this.form.markAllAsTouched();
    if (this.form.invalid) return;
    const todo = this.form.value as Todo;
    this.isSubmitting = true;
    this.todoService.addTodo(todo).pipe(
      finalize(() => this.isSubmitting = false),
      takeUntilDestroyed(this.destroyRef$)
    ).subscribe(todo => this.dialogRef.close(todo));
  }
}
