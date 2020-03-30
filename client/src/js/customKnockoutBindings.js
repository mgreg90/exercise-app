import ko from 'knockout'

const applyCustomKnockoutBindings = _ => {
  ko.bindingHandlers.onEnter = {
    init: (element, valueAccessor, allBindings, viewModel) => {
      element.addEventListener('keypress', () => {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
          valueAccessor().call(viewModel);
          return false;
        }
        return true;
      })
    }
  }
}
export default applyCustomKnockoutBindings