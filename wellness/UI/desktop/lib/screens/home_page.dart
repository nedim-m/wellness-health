import 'package:desktop/screens/category_page.dart';
import 'package:desktop/screens/record_page.dart';
import 'package:desktop/screens/reservation_page.dart';
import 'package:desktop/screens/treatment_page.dart';
import 'package:desktop/screens/treatment_type_page.dart';
import 'package:desktop/screens/user_page.dart';
import 'package:desktop/screens/worker_page.dart';
import 'package:desktop/utils/role_store.dart';
import 'package:desktop/utils/token_store.dart';
import 'package:fluent_ui/fluent_ui.dart';

import 'membership_type.dart';

class HomepageView extends StatefulWidget {
  const HomepageView({super.key});

  @override
  State<HomepageView> createState() => _HomepageViewState();
}

class _HomepageViewState extends State<HomepageView> {
  int topIndex = 0;
  bool isAdmin = false;

  PaneDisplayMode displayMode = PaneDisplayMode.top;

  List<NavigationPaneItem> items = [];

  @override
  void initState() {
    super.initState();
    initializeItemsBasedOnRole();
  }

  void removeCredentials() {
    RoleManager.removeIsAdmin();
    TokenManager.removeToken();
  }

  void initializeItemsBasedOnRole() {
    // Get the user's role from RoleManager and set isAdmin accordingly
    isAdmin = RoleManager.getRole() ?? false;

    // Define the items list based on the user's role
    setState(() {
      items = [
        PaneItem(
          icon: const Icon(FluentIcons.people),
          title: const Text('Korisnici'),
          body: const UserPageView(),
        ),
        if (isAdmin)
          PaneItem(
            icon: const Icon(FluentIcons.teamwork),
            title: const Text('Zaposlenici'),
            body: const WorkerPageView(),
          ),
        PaneItem(
          icon: const Icon(FluentIcons.temporary_user),
          title: const Text('Trenutno prisutni'),
          body: const RecordPageView(),
        ),
        PaneItem(
          icon: const Icon(FluentIcons.service_activity),
          title: const Text('Vrste usluge'),
          body: const TreatmentTypePageView(),
        ),
        PaneItem(
          icon: const Icon(FluentIcons.category_classification),
          title: const Text('Kategorije'),
          body: const CategoryPageView(),
        ),
        PaneItem(
          icon: const Icon(FluentIcons.medical_care),
          title: const Text('Tretmani'),
          body: const TreatmentPageView(),
        ),
        PaneItem(
          icon: const Icon(FluentIcons.payment_card),
          title: const Text('Članarina'),
          body: const MembershipTypePageView(),
        ),
        if (!isAdmin)
          PaneItem(
            icon: const Icon(FluentIcons.reservation_orders),
            title: const Text('Rezervacije'),
            body: const ReservationPageView(),
          ),
        if (isAdmin)
          PaneItemExpander(
            title: const Text('Izvjestaj'),
            icon: const Icon(FluentIcons.report_document),
            body: const Text("This is text"),
            items: [
              PaneItem(
                icon: const Icon(FluentIcons.mail),
                title: const Text('Kreiraj'),
                body: const Text("Kreiraj izvjestaj"),
              ),
              PaneItem(
                icon: const Icon(FluentIcons.calendar),
                title: const Text('Prikaži'),
                body: const Text('Prikaži'),
              ),
            ],
          ),
      ];
    });
  }

  @override
  Widget build(BuildContext context) {
    return NavigationView(
      appBar: const NavigationAppBar(
        title: Center(
          child: Text(
            "Wellness center Health",
            style: TextStyle(fontSize: 30),
          ),
        ),
      ),
      pane: NavigationPane(
        selected: topIndex,
        onChanged: (index) => setState(() => topIndex = index),
        displayMode: displayMode,
        items: items,
        footerItems: [
          PaneItem(
            icon: const Icon(FluentIcons.leave_user),
            title: const Text('Odjava'),
            body: const Text("Home6"),
            onTap: () {
              removeCredentials();
              Navigator.pop(context);
            },
          ),
        ],
      ),
    );
  }
}
