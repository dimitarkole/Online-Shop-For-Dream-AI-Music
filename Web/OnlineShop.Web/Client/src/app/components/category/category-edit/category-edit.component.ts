import { Component, OnInit, Input } from '@angular/core';
import { AbstractControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import Category from '../../../shared/models/category';
import { CategoryService } from '../../../core/services/category.service';
import { AuthService } from '../../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
  categoryForm: FormGroup;
  categoryId: string;
  constructor(private categoryService: CategoryService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    var category = this.route.snapshot.data.category;
    this.categoryId = category.id;
    this.categoryForm = this.fb.group({
      name: [category.name, [Validators.required]],
    });
  }

  formHandler() {
    let category: Category = this.categoryForm.value;

    this.categoryService.edit(category, this.categoryId)
      .subscribe(_ => {
        this.router.navigate(['category', 'all']);
      });

    this.categoryForm.reset();
  }

  get name(): AbstractControl {
    return this.categoryForm.get('name');
  }
}
