import regeneratorRuntime from 'regenerator-runtime'
import page from "page"

import applyCustomKnockoutBindings from './misc/customKnockoutBindings'
import registerRoutes, { routes } from './misc/routes'

applyCustomKnockoutBindings()

const appBody = document.getElementById('APPLICATION_BODY')
registerRoutes(appBody)

page(routes.LOGIN)