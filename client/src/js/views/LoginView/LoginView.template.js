const html = /*html*/`
  <div class="uk-position-center uk-text-center" uk-grid>
    <div class="uk-card uk-card-default uk-card-body">
      <form>
        <fieldset class="uk-fieldset">
          <legend class="uk-legend">Log In</legend>
          <div class="uk-margin">
            <div class="uk-inline">
              <span class="uk-form-icon uk-form-icon-flip" uk-icon="icon: user"></span>
              <input
                id="LoginView-input-email"
                class="uk-input"
                type="text"
                placeholder="Email"
                data-bind="value: email, valueUpdate: 'afterkeydown'"
              >
            </div>
          </div>
          <div class="uk-margin">
            <div class="uk-inline">
              <span class="uk-form-icon uk-form-icon-flip" uk-icon="icon: lock"></span>
              <input
                id="LoginView-input-password"
                class="uk-input"
                type="password"
                placeholder="Password"
                data-bind="value: password, valueUpdate: 'afterkeydown'"
              >
            </div>
          </div>
        </fieldset>
        <p class="error-message"><span data-bind="text: validationError"></span></p>
        <button data-bind="click: submitHandler">Submit</button>
        <a class="uk-link-text" href="/signup">Sign Up</a>
      </form>
    </div>
  </div>
`

export default html