# Version Control — Weekly Presentation Rollout

SAIMS is presented incrementally using Git tags as permanent snapshots. Each version
unlocks exactly one form/feature on top of the previous version. Forms not yet
presented show an "Under Construction" placeholder instead of their real content.

## Rollout Schedule

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---|---|---|---|
| v1.00 | Login / Forgot Password / Dashboard shell | `LoginForm`, `ForgotPasswordForm`, `MainDashboardForm` | `UsersForm`, `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.01 | Admin: Users Management | + `UsersForm` | `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.02 | Admin: Products Management | + `ProductsForm` | `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.03 | Admin: Categories Management | + `CategoriesForm` | `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.04 | Admin: Stock In | + `StockInForm` | `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.05 | Admin: Stock Out | + `StockOutForm` | `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v1.06 | Admin: Inventory Report | + `InventoryReportForm` | `SalesForm`, `ReceiptsForm` |
| v1.07 | Cashier: Sales Transaction (POS) | + `SalesForm` | `ReceiptsForm` |
| v1.08 | Cashier: Receipts (Full System) | + `ReceiptsForm` | *(none — full system unlocked)* |

## Round 2 Rollout (v2.00+)

Once the v1.xx series reached full unlock, the gate was reset to start a second
presentation round under the `v2.xx` tag series. This mirrors the v1.xx schedule
form-for-form, but v2.00 also carries the Login "Show Password" checkbox fix
(`chkShowPassword_CheckedChanged` now toggles `txtPassword.PasswordChar` directly,
since `UseSystemPasswordChar` alone has no effect once `PasswordChar` is explicitly
set on the control).

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---|---|---|---|
| v2.00 | Login / Forgot Password / Dashboard shell (+ show-password fix) | `LoginForm`, `ForgotPasswordForm`, `MainDashboardForm` | `UsersForm`, `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.01 | Admin: Users Management | + `UsersForm` | `ProductsForm`, `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.02 | Admin: Products Management | + `ProductsForm` | `CategoriesForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.03 | Admin: Categories Management | + `CategoriesForm` | `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.04 | Admin: Stock In | + `StockInForm` | `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.05 | Admin: Stock Out | + `StockOutForm` | `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |
| v2.06 | Admin: Inventory Report | + `InventoryReportForm` | `SalesForm`, `ReceiptsForm` |
| v2.07 | Cashier: Sales Transaction (POS) | + `SalesForm` | `ReceiptsForm` |
| v2.08 | Cashier: Receipts (Full System) | + `ReceiptsForm` | *(none — full system unlocked)* |

`CURRENT_VERSION_NUMBER` was reset to `0` (from `8`) in `UnderConstructionForm.vb`
to re-lock every gated form; `CURRENT_VERSION` was bumped to `"v2.00"`. The
per-form required versions (1–8) in `MainDashboardForm.vb`'s `LoadGatedForm` calls
did not change — only the baseline they're compared against did.

Note: unlike a two-portal (admin/patient) app, SAIMS has a single `MainDashboardForm`
shell whose Setup menu is hidden for non-admin roles (`ApplyRoleAccess` in
`MainDashboardForm.vb`). "Admin" rows above are the Setup/Reports forms; "Cashier"
rows are the Transactions forms available to all roles.

## Round 3 Rollout (v3.00+)

Once the v2.xx series reached full unlock, the gate was reset again to start a
third presentation round under the `v3.xx` tag series. Unlike v1/v2, this round
does **not** unlock forms in the same order: `CategoriesForm` moves ahead of
`UsersForm`/`ProductsForm`, so v3.00 unlocks Login *and* Categories together
while Users/Products (and everything after) stay gated.

| Version | Feature Unlocked | Forms Unlocked | Forms Still Gated |
|---|---|---|---|
| v3.00 | Login / Forgot Password / Dashboard shell + Admin: Categories Management | `LoginForm`, `ForgotPasswordForm`, `MainDashboardForm`, `CategoriesForm` | `UsersForm`, `ProductsForm`, `StockInForm`, `StockOutForm`, `InventoryReportForm`, `SalesForm`, `ReceiptsForm` |

`CURRENT_VERSION_NUMBER` was reset to `1` (from `8`) in `UnderConstructionForm.vb`
to re-lock every form except `CategoriesForm`; `CURRENT_VERSION` was bumped to
`"v3.00"`. Because Categories now unlocks first, the per-form required versions
in `MainDashboardForm.vb`'s `LoadGatedForm` calls were renumbered (see updated
table below) — `CategoriesForm` is now `1`, `UsersForm`/`ProductsForm` shifted to
`2`/`3`, and `StockInForm`/`StockOutForm`/`InventoryReportForm`/`SalesForm`/
`ReceiptsForm` keep their prior slots (`4`–`8`) since Categories/Users/Products
still only occupy 3 slots total.

## The Under Construction Strategy

Gating is centralized in `MainDashboardForm.vb`, not scattered across each form.
Every Setup/Transactions/Reports menu button routes through one helper:

```vb
Private Sub LoadGatedForm(requiredVersion As Integer, formFactory As Func(Of Form))
    If requiredVersion <= UnderConstructionForm.CURRENT_VERSION_NUMBER Then
        LoadFormInPanel(formFactory())
    Else
        LoadFormInPanel(New UnderConstructionForm())
    End If
End Sub
```

Each menu click passes its own required version, e.g. `btnUsers_Click` calls
`LoadGatedForm(1, Function() New UsersForm())`. `LoadFormInPanel` is the existing
helper that docks whatever form it's given (`Dock = Fill`) into `panelContent` —
so `UnderConstructionForm` is shown the exact same way as any real form: maximized
inside the dashboard's content area, not as a popup dialog. This also means a
locked form's own code (and its DB queries) never even runs — `LoadGatedForm`
simply never constructs it.

`Forms/UnderConstructionForm.vb` is the placeholder shown when locked:

- `Public Const CURRENT_VERSION As String = "v1.08"` and
  `Public Const CURRENT_VERSION_NUMBER As Integer = 8` — bumped together once per
  version. The string drives the on-screen "Current Version" label; the integer
  drives the `<=` comparison in `LoadGatedForm`.
- Dark blue background (`#1A237E`) fills the whole content panel, with a centered
  box (🚧 emoji, orange "Current Version" label, white "Under Construction" title,
  description) that re-centers itself on resize (`UnderConstructionForm_Resize`),
  since `panelContent` is maximized and can be different sizes on different screens.

### Per-form required versions

As of the v3.xx round:

| Form | Required Version |
|---|---|
| `CategoriesForm` | 1 |
| `UsersForm` | 2 |
| `ProductsForm` | 3 |
| `StockInForm` | 4 |
| `StockOutForm` | 5 |
| `InventoryReportForm` | 6 |
| `SalesForm` | 7 |
| `ReceiptsForm` | 8 |

To unlock a version, bump **both** constants in `UnderConstructionForm.vb` — no
per-form edits are needed anymore.

## Git Commands Per Version

```bash
# Unlocking a version only requires bumping CURRENT_VERSION / CURRENT_VERSION_NUMBER
# in Forms/UnderConstructionForm.vb — stage and commit just that file
git add Forms/UnderConstructionForm.vb
git commit -m "feat: implement vX.XX - unlock [Feature Name]"

# Tag the commit and push both
git tag vX.XX
git push origin main
git push origin vX.XX
```

### How Git Tags Work

A tag is a permanent, named pointer to a specific commit. Unlike branches, tags
don't move — `git checkout v1.03` always returns exactly the state of the project
as of the v1.03 presentation, regardless of what happens on `main` afterward. This
is what lets old presentation snapshots be revisited later without special
branches.

## GitHub Release Tags

Fill in the commit hash column after all versions have been tagged and pushed,
using:

```bash
git tag | sort | xargs -I{} git log -1 --format="{} %H" {}
```

| Version | Tag | Commit Hash |
|---|---|---|
| v1.00 | `v1.00` | `3ac75937de3c7d451b010bba0ef052a218850535` |
| v1.01 | `v1.01` | `fe7feed9475422082ec7c28d5983cccee573a754` |
| v1.02 | `v1.02` | `c7c7dd1c61198ea92e3f115dbb41490dd2667bc6` |
| v1.03 | `v1.03` | `06d86b7805eb9f8d765b86c20180b91bac561be3` |
| v1.04 | `v1.04` | `da80bf8a3ef3e4947ad272ea32d7f085cbb0aa42` |
| v1.05 | `v1.05` | `1c8aeb0ae2c76242b33bbdb0cc288c84f8e47467` |
| v1.06 | `v1.06` | `af40a1e521633b5f635fc2b32b07fca67eff93af` |
| v1.07 | `v1.07` | `c7d664522e6fb0816b94689aa1ea3d86580c8b21` |
| v1.08 | `v1.08` | `4b1ce2f6c991a5f58cf3971063f65d53804798a6` |

Note: these tags were moved on 2026-07-06 to point at the corrected embedded-gate
implementation, per the "prof requests changes" procedure below — the original
v1.00–v1.08 commits used a popup-dialog gate that has been superseded.

## When a Prof or Client Requests Changes After a Presentation

Fix the issue on `main`, then move the affected version's tag to point at the fix
so the "snapshot" for that version reflects the corrected state:

```bash
# Fix on main first
git checkout main
git add .
git commit -m "feat: update [form] per feedback"
git push origin main

# Delete old tag and re-create it pointing to the new commit
git tag -d vX.XX
git push origin :refs/tags/vX.XX
git tag vX.XX
git push origin vX.XX
```

Only move the tag for the version actually being corrected — earlier tags stay
untouched so previously presented snapshots remain reproducible.
