import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CatalogService } from '../catalog.service';


@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent {

  @Input('number-of-pages') numberOfPages: number;
  @Output('page-changed') pageChanged = new EventEmitter<number>();

  pageOptions: number[];
  
  currentPage = 1;

  constructor(private catalogService: CatalogService){
    this.catalogService.numberOfPages.subscribe(result => {
      if (this.currentPage > result) {
        this.currentPage = 1;
      }

    });
  }

  ngOnChanges(){
  
    this.pageOptions = [
      this.currentPage - 2,
      this.currentPage - 1,
      this.currentPage ,
      this.currentPage + 1,
      this.currentPage + 2,
    ].filter(pageNumber => pageNumber >= 1 && pageNumber <= this.numberOfPages)
  }
  
  changePage(page){
		this.currentPage = page; 
		this.pageChanged.emit(page);
	}
  
	previous(){
		if (this.currentPage == 1)
			return;

		this.currentPage--;
		this.pageChanged.emit(this.currentPage);
	}
	next(){
		if (this.currentPage == this.numberOfPages)
			return;

		this.currentPage++;
		this.pageChanged.emit(this.currentPage);
	}

}
