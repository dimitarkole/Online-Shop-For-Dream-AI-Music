import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-delete',
  templateUrl: './category-delete.component.html',
  styleUrls: ['./category-delete.component.css']
})
export class CategoryDeleteComponent {
  constructor(public modal: NgbActiveModal,
    private router: Router,
    private authService: AuthService) {
    if ((authService.isAuth == false) || (authService.isAdmin == false)) {
      this.router.navigate(['']);
    }
  }

}
