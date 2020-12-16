import { Component, OnInit } from '@angular/core';
import Category from '../../../shared/models/category';
import { globalConstants } from '../../../common/global-constants';
import getPage from '../../../common/paginator';
import { CategoryService } from '../../../core/services/category.service';
import { CategoryEditComponent } from '../category-edit/category-edit.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { CategoryDeleteComponent } from '../category-delete/category-delete.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  page: number = globalConstants.pagination.defaultPage;
  itemsPerPage: number = globalConstants.pagination.itemsPerPage;
  collectionSize: number;
  categories: Category[] = [];
  allCategories: Category[] = [];

  constructor(private modalService: NgbModal,
    private categoryService: CategoryService,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.categoryService.all().subscribe(data => {
      this.allCategories = data;
      this.getCategoriesPerPage(this.page);
    })
  }

  openDelete(categoryId: string) {
    let modal = this.modalService.open(CategoryDeleteComponent);
    modal.result.then(value => {
      debugger;
      this.categoryService.delete(categoryId).toPromise()
        .then(_ => {
          this.router.navigate(['/category/all']);
        })
    }).catch(err => {
      console.log(err);
    })
  }

  public getCategoriesPerPage(page: number): void {
    this.categories = getPage<Category>(this.allCategories, page, this.itemsPerPage);
  }
}
