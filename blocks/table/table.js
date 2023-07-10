/*
 * Table Block
 * Recreate a table
 * https://www.hlx.live/developer/block-collection/table
 */

function buildCell(rowIndex) {
  const cell = rowIndex ? document.createElement('td') : document.createElement('th');
  if (!rowIndex) cell.setAttribute('scope', 'col');
  return cell;
}
export default async function decorate(block) {
  const table = document.createElement('table');
  const thead = document.createElement('thead');
  const tbody = document.createElement('tbody');
  table.append(thead, tbody);
  [...block.children].forEach((child, i) => {
    const row = document.createElement('tr');
    const td = document.createElement('td');
    const colspan = document.createElement('colspan');
    if (i) tbody.append(row, td, colspan);
    else thead.append(row, td, colspan);
    [...child.children].forEach((col) => {
      const cell = buildCell(i);
      const cell2 = buildCell(colspan);
      cell.innerHTML = col.innerHTML;
      row.append(cell);
      colspan.appendChild(cell2);
    });
  });
  block.innerHTML = '';
  block.append(table);
}
