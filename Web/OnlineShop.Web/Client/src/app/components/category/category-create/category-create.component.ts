import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../core/services/category.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';
import Category from '../../../shared/models/category';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {
  categoryForm: FormGroup;

  constructor(private categoryService: CategoryService,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.categoryForm = this.fb.group({
      name: [null, [Validators.required]],
    });
  }

  formHandler() {
    let category: Category = this.categoryForm.value;

    this.categoryService.create(category)
      .subscribe(_ => {
        this.router.navigate(['category', 'all']);
      });

    this.categoryForm.reset();
  }

  get name(): AbstractControl {
    return this.categoryForm.get('name');
  }
}
