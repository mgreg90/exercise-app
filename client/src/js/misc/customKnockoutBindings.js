import ko from 'knockout'

const ENTER_KEY = 13

const applyCustomKnockoutBindings = _ => {
  ko.bindingHandlers.onEnter = {
    init: (element, valueAccessor, allBindings, viewModel) => {
      element.addEventListener('keypress', () => {
        var keyCode = event.which || event.keyCode
        if (keyCode === ENTER_KEY) {
          valueAccessor().call(viewModel)
          return false
        }
        return true
      })
    }
  }
}
export default applyCustomKnockoutBindings