import { Directive, HostBinding, HostListener, Host } from '@angular/core';

@Directive({
  selector: '[appDropdown]'
})
export class DropdownDirective {

  @HostBinding('class.dropdown-menu.show') isOpen: boolean = false;
  @HostBinding('class.nav-link.dropdown-toggle.show') isLinkShow: boolean = false;
  //@HostBinding('aria-expanded.false') isExpanded: boolean;

  @HostListener('click') toggleOpen() {
    this.isOpen = !this.isOpen;
    this.isLinkShow = !this.isLinkShow;
    //this.isExpanded = !this.isExpanded;
  }

}
