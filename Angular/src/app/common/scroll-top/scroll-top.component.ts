import { DOCUMENT } from '@angular/common';
import { Component, OnInit, Inject, HostListener } from '@angular/core';

@Component({
  selector: 'app-scroll-top',
  templateUrl: './scroll-top.component.html',
  styleUrls: ['./scroll-top.component.scss']
})
export class ScrollTopComponent implements OnInit {
  windowScrolled: boolean | undefined;
  constructor(@Inject(DOCUMENT) private document: Document) {}
  @HostListener("window:scroll", [])
  onWindowScroll() {
      if (window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop > 100) {
          this.windowScrolled = true;
      } 
     else if (this.windowScrolled && window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop < 10) {
          this.windowScrolled = false;
      }
  }
  scrollToTop() {
    window.scroll(0,0);
    //   (function smoothscroll() {
    //       var currentScroll = document.documentElement.scrollTop || document.body.scrollTop;
    //         console.log(currentScroll);
    //         window.scroll({ 
    //             top: 0, 
    //             left: 0, 
    //             behavior: 'smooth' 
    //      });
    //       if (currentScroll > 0) {
    //           window.requestAnimationFrame(smoothscroll);
    //           window.scrollTo(0, currentScroll - (currentScroll / 8));
    //       }

    //   })();
  }
  ngOnInit() {}
}