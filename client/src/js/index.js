import regeneratorRuntime from 'regenerator-runtime'

import ko from "knockout"
import LoginView from './views/LoginView'
import applyCustomKnockoutBindings from './customKnockoutBindings'

applyCustomKnockoutBindings()

const appBody = document.getElementById('APPLICATION_BODY')
console.log('Application Body', appBody)

const view = LoginView()

appBody.innerHTML = view.html;
ko.applyBindings(new view.viewModel())