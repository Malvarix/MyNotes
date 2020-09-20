describe('Test 1', function(){
  it('Test 1.1 - Attempt to visiting site', function(){
    cy.visit('http://localhost:4200/');
    //BEFORE EACH TEST RESTART THE SERVER TO RESTORE DATA
    //cy.get('.custom-select').select('en').should('have.value','en'); //<<-- TEST FOR EN LOCALIZATION (DEFAULT)
    //cy.get('.custom-select').select('de').should('have.value','de'); //<<-- TEST FOR DE LOCALIZATION
    //cy.get('.custom-select').select('ru').should('have.value','ru'); //<<-- TEST FOR RU LOCALIZATION
  })
  it('Test 1.2 - Attempt to add empty note', function(){
    cy.get('.add').click();
    cy.url().should('include', '/create');
    cy.get('.create').click();
    cy.on('window:alert', (str) => {
      expect(str).to.equal(`Please, fill description field!`);
    });
    cy.get('.cancel').click();
    cy.url().should('include', '/');
  })
  it('Test 1.3 - Attempt to add note without picked priority', function(){
    cy.get('.add').click();
    cy.url().should('include', '/create');
    cy.get('.text-a').type('Default test description1').should('have.value','Default test description1');
    cy.get('.create').click();
    cy.url().should('include', '/');
    cy.get('.notes').contains('Default test description1');
  })
  it('Test 1.4 - Attempt to add note with picked priority', function(){
    cy.get('.add').click();
    cy.url().should('include', '/create');
    cy.get('.text-a').type('Default test description2').should('have.value','Default test description2');
    cy.get('.pr-select').select('High').should('have.value','High');
    cy.get('.create').click();
    cy.url().should('include', '/');
    cy.get('.notes').contains('Default test description');
  })
  it('Test 1.5 - Attempt to edit all notes with new description', function(){
      cy.get('.edit').each(($edit, index) => {
        cy.get('.edit').eq(index).click();
        cy.url().should('include', '/edit');
        cy.get('.text-a').clear().type('Default test description3').then($input => {
          expect($input.val()).to.contain('Default test description3')
        })
        cy.get('.save').click();
        cy.url().should('include', '/');
        cy.get('.notes').contains('Default test description3');
      })
  })
  it('Test 1.6 - Attempt to edit all notes with new description & new priority', function(){
    cy.get('.edit').each(($edit, index) => {
      cy.get('.edit').eq(index).click();
      cy.url().should('include', '/edit');
      cy.get('.text-a').clear().type('Default test description4').then($input => {
        expect($input.val()).to.contain('Default test description4')
      })
      cy.get('.pr-select').select('Intermediate').should('have.value','Intermediate');
      cy.get('.save').click();
      cy.url().should('include', '/');
      cy.get('.notes').contains('Default test description4');
    })
  })
  it('Test 1.7 - Attempt to delete all notes', function(){
    cy.get('.wrap-bts').find('.delete').should('be.visible').then((e) => { Cypress.$(e).click() });
  })
})
